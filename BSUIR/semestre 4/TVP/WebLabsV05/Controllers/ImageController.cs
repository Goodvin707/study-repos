using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WebLabsV05.DAL.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;

namespace WebLabsV05.Controllers
{
    public class ImageController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        IHostingEnvironment _env;

        public ImageController(UserManager<ApplicationUser> mngr, IHostingEnvironment env)
        {           
            _userManager = mngr;
            _env = env;
        }

        public async Task<IActionResult> GetAvatar()
        {
            var user = await _userManager.GetUserAsync(User);
            if(user.AvatarImage!=null)
                return File(user.AvatarImage, user.ImageMimeType);
            else
            {                
                var avatarPath = "/Images/anonymous.jpg";                
                var extProvider = new FileExtensionContentTypeProvider();
                var mimeType = extProvider.Mappings[".jpg"];
                return File(_env.WebRootFileProvider.GetFileInfo(avatarPath).CreateReadStream(), 
                            mimeType);
            }
        }
    }
}