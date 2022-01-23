using System;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Security;

namespace Building.A.RESTful.API.With.NancyFx;

public class PersonModule : NancyV1Module
{
    public PersonModule() : base("rest/person")
    {
        this.RequiresAuthentication();
        this.RequiresClaims(c => c.Value == UserIdentity.HANDLEPERSON_PERMISSION);

        Get[""] = GetAllAction;
        Get["{id:int}"] = GetAction;
        Post[""] = AddAction;
        Put["{id:int}"] = ModifyAction;
        Delete["{id:int}"] = DeleteAction;
    }

    private dynamic GetAllAction(dynamic parameters)
    {
        return PersonRepository.Instance.GetAll();
    }

    private dynamic GetAction(dynamic parameters)
    {
        int id = parameters.id;

        return PersonRepository.Instance.Get(id);
    }

    private dynamic AddAction(dynamic parameters)
    {
        var model = this.BindAndValidate<Person>();
        if (!ModelValidationResult.IsValid) throw new ApplicationException("Object is not a valid person");

        PersonRepository.Instance.Add(model);

        return HttpStatusCode.OK;
    }

    private dynamic ModifyAction(dynamic parameters)
    {
        var model = this.BindAndValidate<Person>();
        if (!ModelValidationResult.IsValid) throw new ApplicationException("Object is not a valid person");

        PersonRepository.Instance.Modify(model);

        return HttpStatusCode.OK;
    }

    private dynamic DeleteAction(dynamic parameters)
    {
        var model = this.BindAndValidate<Person>();
        if (!ModelValidationResult.IsValid) throw new ApplicationException("Object is not a valid person");

        PersonRepository.Instance.Delete(model);

        return HttpStatusCode.OK;
    }
}