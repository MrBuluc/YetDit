﻿using MediatR;
using YetDit.Application.DTOs.User;

namespace YetDit.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandResponse : IRequest<CreateUserCommandRequest>
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }

        public static explicit operator CreateUserCommandResponse(CreateUserResponse response) => new()
        {
            Succeeded = response.Succeeded,
            Message = response.Message
        };
    }
}
