﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Blog.Data.FileManager
{
    public class FileManager:IFileManager
    {
        private string _imagePath;
        public FileManager(IConfiguration config)
        {
            _imagePath = config["Path:Images"]; 
        }

        public FileStream ImageStream(string image)
        {
            return new FileStream(Path.Combine(_imagePath, image), FileMode.Open,FileAccess.Read);
        }
        bool IFileManager.RemoveImage(string image)
        {
            try {
                var file = Path.Combine(_imagePath, image);
                if(File.Exists(file))
                    File.Delete(file);
                return true;
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public async Task<string> SaveImage(IFormFile image)
        {
            try
            {
                var save_path = Path.Combine(_imagePath);
                if (!Directory.Exists(save_path))
                {
                    Directory.CreateDirectory(save_path);
                }

                var mime = image.FileName.Substring(image.FileName.LastIndexOf("."));
                var fileName = $"img_{DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss")}{mime}";

                using (var fileStream = new FileStream(Path.Combine(save_path, fileName), FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
                return fileName;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return "Error";
            }
            
        }
    }
}
