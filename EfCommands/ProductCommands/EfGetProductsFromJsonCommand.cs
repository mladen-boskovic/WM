using Application.Commands.ProductCommands;
using Application.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommands.ProductCommands
{
    public class EfGetProductsFromJsonCommand : IGetProductsFromJsonCommand
    {
        public IEnumerable<ProductDto> Execute()
        {
            StreamReader streamReader = new StreamReader(@"C:\Users\mlade\Documents\wm\JsonData\Products.json");
            string json = streamReader.ReadToEnd();
            var products = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(json);
            return products;
        }
    }
}
