﻿namespace FeedbackApp.Application.Requests
{
    public class LoginRequest
    {
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;
    }
}
