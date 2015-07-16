using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCInstagramFatih.Models
{
    public class CommentModeModel
    {
        public int PhotoId { get; set; }
        public int UserId { get; set; }
        public string CommentStr { get; set; }
    }
}