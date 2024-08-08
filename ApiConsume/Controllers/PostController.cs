using ApiConsume.Models;
using ApiConsume.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace ApiConsume.Controllers
{
    public class PostController : Controller
    {
        private readonly IApiService _apiService;

        public PostController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _apiService.GetAsync<List<Post>>("https://jsonplaceholder.typicode.com/posts");

            if (result != null && result.Any())
            {
                return View(result);
            }
            return View(); //Todo : Watch error
        }

        public async Task<IActionResult> Detail(int id)
        {
            var result = await _apiService.GetAsync<Post>($"https://jsonplaceholder.typicode.com/posts/{id}");

            if (result != null)
            {
                return View(result);
            }
            return View(); //Todo : Watch error
        }

        public async Task<IActionResult> Delete(int id)
        {
            
            var data = await _apiService.GetAsync<Post>($"https://jsonplaceholder.typicode.com/posts/{id}");

            if (data != null)
            {
                return View(data);
            }

            return View(); //Todo : Watch error
        }

        [HttpPost]
        public async Task<IActionResult> Delete(PostDeleteDto postDeleteDto)
        {
             
             var result = await _apiService.DeleteAsync($"https://jsonplaceholder.typicode.com/posts/{postDeleteDto.Id}");

             if (result == true)
             {
                 return RedirectToAction("Index");
             }
            
            return View(); //Todo : Watch error
        }

        public async Task<IActionResult> Edit(int id)
        {

            var data = await _apiService.GetAsync<Post>($"https://jsonplaceholder.typicode.com/posts/{id}");

            if (data == null)
            {
                return NotFound(); //Todo : Watch error
            }
            return View(data); 
          
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            var result = await _apiService.PutAsync($"https://jsonplaceholder.typicode.com/posts/{id}", post);

            if (result != null)
            {
                return RedirectToAction("Index");
            }

            // Eğer güncelleme başarısız olursa tekrar aynı sayfayı hata mesajıyla gösterebiliriz
            ModelState.AddModelError(string.Empty, "An error occurred while updating the post.");
            return View(post);
        }
    }
}
