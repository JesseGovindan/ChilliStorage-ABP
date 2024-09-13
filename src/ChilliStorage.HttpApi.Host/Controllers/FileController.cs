using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ChilliStorage.Interfaces;
using Volo.Abp.AspNetCore.Mvc;

namespace ChilliStorage.Controllers
{
    [Route("api/file")]
    public class FileController : AbpController
    {
        private readonly IDocumentConsignmentService _documentConsignmentService;

        public FileController(IDocumentConsignmentService documentConsignmentService)
        {
            _documentConsignmentService = documentConsignmentService;
        }

        [HttpGet]
        [Route("download/{consignmentNumber}")]
        public async Task<IActionResult> DownloadAsync(string consignmentNumber)
        {
            var fileDto = await _documentConsignmentService.GetDownloadConsignmentDocumentAsync(consignmentNumber);
            var file = new DownloadResult
            {
                File = fileDto
            };
            return Ok(file);
        }

        internal class DownloadResult
        {
            public string File { get; set; } = null!;
        }
    }
}
