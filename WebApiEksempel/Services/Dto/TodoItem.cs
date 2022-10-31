﻿namespace WebApiEksempel.Services.Dto
{
    public class TodoItem
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public bool Completed { get; set; }

    }
}
