using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TwitchNightFall.Core.Application.Common;
using TwitchNightFall.Core.Application.Services;

namespace TwitchNightFall.Api.Controllers;

public class FileController : BaseController
{
    private readonly IFileService _fileService;

    public FileController(IFileService fileService)
    {
        _fileService = fileService;
    }

    /// <summary>
    /// دانلود تصاویر پروفایل ادمین
    /// </summary>
    /// <param name="filename">عنوان فایلی که در خروجی فایل آپلود به کاربر داده می شود</param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(byte[]))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Download(string filename)
    {
        var content = await _fileService.DownloadAsync(filename);

        return File(content, ContentHelper.ToContentType(filename));
    }

    /// <summary>
    /// آپلود تصاویر پروفایل ادمین
    /// </summary>
    /// <param name="file">فایل جهت آپلود شدن در فایل سرور</param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        var filename = await _fileService.Upload(file);

        var downloadLink = (Request.IsHttps ? "https" : "http") + $"://{Request.Host}/File/Download?filename={filename}";

        return Ok(Result.WithSuccess(new
        {
            Filename = filename,
            DownloadLink = downloadLink
        }));
    }
}