using BlogProjem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjem.ViewComponets
{
    public class CommentList : ViewComponent
    {
        //çağır-->İNVOKE
        public IViewComponentResult Invoke()
        {
            var commentvalues = new List<UserComment>
            {
                new UserComment
                {
                    ID=1,
                    Username="Yusuf"
                },
                new UserComment
                {
                    ID=2,
                    Username="Akif"
                },
                new UserComment
                {
                    ID=3,
                    Username="Kaan"
                },
            };
            return View(commentvalues);
        }

    }
}
