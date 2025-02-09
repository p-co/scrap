﻿namespace Scrap.Model
{
    public class Website
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Link { get; set; }
        public required string HtmlDisposition { get; set; }
    }
}
