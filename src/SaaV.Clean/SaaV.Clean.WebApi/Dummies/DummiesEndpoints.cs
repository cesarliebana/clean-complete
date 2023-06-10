﻿using FluentValidation;
using MediatR;
using SaaV.Clean.Application.Dummies.Requests;
using SaaV.Clean.Application.Dummies.Responses;

namespace SaaV.Clean.WebApi.Dummies
{
    internal static class DummiesEndpoints
    {
        public static async Task<IResult> GetAllDummies(IMediator mediator)
        {
            GetAllDummiesRequest getAllDummiesRequest = new();
            GetAllDummiesResponse getAllDummiesResponse = await mediator.Send(getAllDummiesRequest);
            
            return Results.Ok(getAllDummiesResponse);
        }

        public static async Task<IResult> GetDummyById(int id, IMediator mediator)
        {
            GetDummyByIdRequest getDummyByIdRequest = new(id);
            GetDummyResponse getDummyByIdResponse = await mediator.Send(getDummyByIdRequest);
            
            return Results.Ok(getDummyByIdResponse);
        }

        public async static Task<IResult> CreateDummy(CreateDummyModel createDummyModel, IValidator<CreateDummyModel> validator, IMediator mediator)
        {
            validator.ValidateAndThrow(createDummyModel);

            CreateDummyRequest createDummyRequest = new(createDummyModel.Name!);
            GetDummyResponse createDummyResponse = await mediator.Send(createDummyRequest);
            
            return Results.Created($"/dummies/{createDummyResponse.Id}", createDummyResponse);
        }

        public static async Task<IResult> UpdateDummy(int id, UpdateDummyModel updateDummyModel, IValidator<UpdateDummyModel> validator, IMediator mediator)
        {
            validator.ValidateAndThrow(updateDummyModel);

            UpdateDummyRequest updateDummyRequest = new(id, updateDummyModel.Name!);
            GetDummyResponse updateDummyResponse = await mediator.Send(updateDummyRequest);
                       
            return Results.Ok(updateDummyResponse);
        }

        public static async Task<IResult> DeleteDummy(int id, IMediator mediator)
        {
            DeleteDummyRequest deleteDummyRequest = new(id);
            await mediator.Send(deleteDummyRequest);
            
            return Results.NoContent();
        }
    }
}
