﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarSiteSecond.Models.DTOs;

namespace CarSiteSecond.Models.Requests
{
    public class ColorRequest
    {
        public ColorRequest(List<Color> colors, bool success, string message)
        {
            Colors = colors;
            Success = success;
            Message = message;
        }

        public ColorRequest()
        {
            Colors = new List<Color>();
            Success = false;
            Message = "";
        }

        public List<Color> Colors { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}