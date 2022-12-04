using System;
using System.Collections.Generic;
using System.Linq;

namespace Building.A.RESTful.API.With.NancyFx;

public class PersonRepository
{
    private static PersonRepository _instance;
    private readonly Dictionary<int, Person> _repo;

    private PersonRepository()
    {
        _repo = new Dictionary<int, Person>();
    }

    public static PersonRepository Instance => _instance ??= new PersonRepository();

    public Person[] GetAll()
    {
        return _repo.Values.ToArray();
    }

    public Person Get(int id)
    {
        return !_repo.ContainsKey(id) ? throw new ApplicationException(string.Format("Person with id {0} doesnot exist", id)) : _repo[id];
    }

    public void Add(Person person)
    {
        if (_repo.ContainsKey(person.Id))
        {
            throw new ApplicationException(string.Format("Person with id {0} already exists", person.Id));
        }

        _repo.Add(person.Id, person);
    }

    public void Modify(Person person)
    {
        if (!_repo.ContainsKey(person.Id))
        {
            throw new ApplicationException(string.Format("Person with id {0} doesnot exist", person.Id));
        }

        _repo[person.Id] = person;
    }

    public void Delete(Person person)
    {
        if (!_repo.ContainsKey(person.Id))
        {
            throw new ApplicationException(string.Format("Person with id {0} doesnot exist", person.Id));
        }

        _ = _repo.Remove(person.Id);
    }
}