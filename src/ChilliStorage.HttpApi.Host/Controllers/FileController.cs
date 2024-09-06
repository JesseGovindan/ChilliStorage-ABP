using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ChilliStorage.Interfaces;
using Volo.Abp.AspNetCore.Mvc;

namespace ChilliStorage.Controllers
{
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

            return File(fileDto, "application/octet-stream", "file.pdf");
        }
    }
}
