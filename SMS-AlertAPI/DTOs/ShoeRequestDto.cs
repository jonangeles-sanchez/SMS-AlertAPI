﻿namespace SMS_AlertAPI.DTOs
{
    public class ShoeRequestDto
    {
        public int Id { get; set; }
        public int PhoneNumber { get; set; }
        public List<ShoeDTO> requestedShoes { get; set; }
    }
}