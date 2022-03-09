using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TwitchNightFall.Common.Common;
using TwitchNightFall.Core.Application.Services;

namespace TwitchNightFall.Api.Controllers;

public class FileController : ApplicationController
{
    private readonly IFileService _fileService;

    public FileController(IFileService fileService)
    {
        _fileService = fileService;
    }

    /// <summary>
    /// Download admin profile pictures
    /// </summary>
    /// <param name="filename">The title of the file given to the user at the output of the upload file</param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(byte[]))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status403Forbidden, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpGet]
    [Authorize(Policy = JwtService.Administrator)]
    public async Task<IActionResult> Download(string filename)
    {
        var content = await _fileService.DownloadAsync(filename);

        return File(content, ContentHelper.ToContentType(filename));
    }

    /// <summary>
    /// Upload admin profile pictures
    /// </summary>
    /// <param name="file">File to upload to file server</param>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, Statement.Success, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status403Forbidden, Statement.UnAuthorized, typeof(Result))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, Statement.Failure, typeof(Result))]
    [HttpPost]
    [Authorize(Policy = JwtService.Administrator)]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        var filename = await _fileService.UploadAsync(file);

        var downloadLink = (Request.IsHttps ? "https" : "http") + $"://{Request.Host}/File/Download?filename={filename}";

        return Ok(Result.WithSuccess(new
        {
            Filename = filename,
            DownloadLink = downloadLink
        }));
    }
}