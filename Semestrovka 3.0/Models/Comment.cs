using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Semestrovka_3._0.Models
{
    public class Comment
    {
        [Required] public int Id { get; set; }
        /// <summary>
        /// айди того, на чьей странице оставлен комментарий
        /// </summary>
        [Required] public int UserId { get; set; }
        [Required] public int WriterId { get; set; }
        [Required] public string Text { get; set; }

       
    }
}
