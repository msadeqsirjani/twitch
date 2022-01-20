using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitchNightFall.Core.Application.Common;
using TwitchNightFall.Core.Application.Services;

namespace TwitchNightFall.Api.Controllers
{
    [Route("[controller]/[action]")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Download(string filename)
        {
            var content = await _fileService.DownloadAsync(filename);

            return File(content, ContentTypeHelper.GetContentType(filename));
        }

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
}
