using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Student
{
    private string firstName;
    private string lastName;
    private string email;
    private int clas;
    DateTime birthDate;

    public Student(string firstName, string lastName, string email, int clas, DateTime birthDate)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.clas = clas;
        this.birthDate = birthDate;
    }

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public int Clas
    {
        get { return clas; }
        set { clas = value; }
    }

    public DateTime BirthDate
    {
        get { return birthDate; }
        set { birthDate = value; }
    }

    public int GetAge()
    {
        var today = DateTime.Today;
        int age = today.Year - birthDate.Year;

        // Verifică dacă studentul nu a avut încă ziua de naștere anul acesta
        if (birthDate.Date > today.AddYears(-age)) age--;

        return age;
    }
}
