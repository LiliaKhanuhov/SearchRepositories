using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RepositoriesManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace RepositoriesManager
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepositoriesController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult PerformSearch([FromQuery]string q)
        {
            try
            {
                RepositoriesBL repositoriesBL = new RepositoriesBL();
                var result = repositoriesBL.PerformSearchAsync(q);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e);
            }
        }

        [HttpPost("[action]")]
        public IActionResult SetData([FromBody] Item item)
        {
            try
            {
                HttpContext.Session.SetString(item.id.ToString(), JsonConvert.SerializeObject(item));

                string? allSelectedItemIds = HttpContext.Session.GetString("AllSelectedItemIds");

                if (string.IsNullOrEmpty(allSelectedItemIds))
                {
                    HttpContext.Session.SetString("AllSelectedItemIds", item.id.ToString());
                }
                else
                {
                    allSelectedItemIds += $"_{item.id.ToString()}";
                    HttpContext.Session.Remove("AllSelectedItemIds");
                    HttpContext.Session.SetString("AllSelectedItemIds", allSelectedItemIds);
                }

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, e);
            }
        }

        [HttpGet("[action]")]
        public IActionResult GetData()
        {
            try
            {
                List<Item> result = new List<Item>();
                string? ids_st = HttpContext.Session.GetString("AllSelectedItemIds");

                if (string.IsNullOrEmpty(ids_st))
                {
                    return Ok(result);
                }

                List<string> ids_ls = ids_st.TrimEnd('_').Split("_").ToList();
                foreach (var id in ids_ls)
                {
                    var item = HttpContext.Session.GetString(id);
                    if (!string.IsNullOrEmpty(item))
                    {
                        result.Add(JsonConvert.DeserializeObject<Item>(item));
                    }
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, e);
            }
        }
    }
}
