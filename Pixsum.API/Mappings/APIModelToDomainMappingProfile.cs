using AutoMapper;
using Pixsum.API.Models;
using Pixsum.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pixsum.API.Mappings
{
    public class APIModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "APIModelToDomainMappingProfile";
            }
        }

        protected override void Configure()
        {
            CreateMap<AccountModel, Account>();
            //TODO : Finish adding the rest of the models
        }

    }
}