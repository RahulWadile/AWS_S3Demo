using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWSDemo.Models;
using AWSDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static AWSDemo.Models.EnumModel;

namespace AWSDemo.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AWSS3FileController : ControllerBase
    {
        private readonly IAWSS3FileService _AWSS3FileService;
        public AWSS3FileController(IAWSS3FileService AWSS3FileService)
        {
            this._AWSS3FileService = AWSS3FileService;
        }

        //[Route("ReadFile/{fileName}")]
        //[HttpGet]
        //public async Task<IActionResult> ReadObjectDataAsync(string fileName)
        //{           
        //    var result = await _AWSS3FileService.ReadfileContent(fileName);

        //    return Content(result, "application/json");
        //   // return Ok(result);
        //}

        [Route("getFile/{fileName}")]
        [HttpGet]
        public async Task<Catalog> GetFile(string fileName)
        {
            try
            {
                var result = await _AWSS3FileService.GetFile(fileName);
                return result;
                // return File(result, "image/png");
            }
            catch
            {
                return null;
            }

        }

        [Route("filesList")]
        [HttpGet]
        public async Task<IEnumerable<Catalog>> FilesListAsync()
        {
            return await _AWSS3FileService.FilesList();

        }

        [Route("uploadFile")]
        [HttpPost]
        public async Task<IActionResult> UploadFileAsync(UploadFileName uploadFileName)
        {
            var result = await _AWSS3FileService.UploadFile(uploadFileName);
            return Ok(new { isSucess = result });
        }

        [Route("updateFile")]
        [HttpPut]
        public async Task<IActionResult> UpdateFile(UploadFileName uploadFileName, string fileName)
        {
            var result = await _AWSS3FileService.UpdateFile(uploadFileName, fileName);
            return Ok(new { isSucess = result });
        }
        [Route("deleteFile/{fileName}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteFile(string fileName)
        {
            var result = await _AWSS3FileService.DeleteFile(fileName);
            return Ok(new { isSucess = result });
        }




    }
}
