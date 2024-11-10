using CompanhiadoCacau.Controllers;
using CompanhiadoCacau.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Xunit;
using System.Threading.Tasks;
using CompanhiadoCacau.Data;

namespace CompanhiadoCacauTest;


public class ClassesTest
{
    [Fact]
    public void Criar_Cliente_Valido()
    {
        // Arrange - Criando um cliente v�lido
        var cliente = new Cliente
        {
            Nome = "Jo�o da Silva",
            //DataNascimento = new DateOnly(1990, 5, 20),
            DataNascimento = new DateOnly(2024, 11, 10),
            CPF = "14264273790",  // CPF v�lido
            Email = "joao.silva@email.com", // E-mail v�lido
            Telefone = "11987654321",  // Telefone v�lido
            EnderecoId = 1
        };

        // Act - Validando o cliente com as anota��es de dados
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(cliente, serviceProvider: null, items: null);
        var isValid = Validator.TryValidateObject(cliente, validationContext, validationResults, true);

        // Assert - Verificando que o cliente � v�lido
        Assert.True(isValid);  // O cliente deve ser v�lido

        // Se o teste falhar, vamos imprimir os erros de valida��o
        if (!isValid)
        {
            Console.WriteLine("Erros de valida��o:");
            foreach (var validationResult in validationResults)
            {
                Console.WriteLine(validationResult.ErrorMessage);  // Imprime as mensagens de erro
            }
        }
    }


    [Fact]
    public void CriarCliente_NomeInvalido_ErroValidacao()
    {
        // Arrange - Criando um cliente com nome inv�lido (nulo ou vazio)
        var cliente = new Cliente
        {
            Nome = "",  // Nome vazio
            DataNascimento = new DateOnly(1990, 5, 20),
            CPF = "123.456.789-00",  // CPF v�lido
            Email = "joao.silva@email.com",
            Telefone = "(11) 98765-4321",
            EnderecoId = 1
        };

        // Act - Validando o cliente com as anota��es de dados
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(cliente, serviceProvider: null, items: null);
        var isValid = Validator.TryValidateObject(cliente, validationContext, validationResults, true);

        // Assert - Verificando que o cliente n�o � v�lido devido ao nome
        Assert.False(isValid);  // O cliente n�o deve ser v�lido
        Assert.Contains(validationResults, vr => vr.MemberNames.Contains("Nome"));  // Erro relacionado ao campo Nome

    }

    [Fact]
    public void CriarCliente_CPFInvalido_ErroValidacao()
    {
        // Arrange - Criando um cliente com CPF inv�lido
        var cliente = new Cliente
        {
            Nome = "Jo�o da Silva",
            DataNascimento = new DateOnly(1990, 5, 20),
            CPF = "000.000.000-00",  // CPF inv�lido
            Email = "joao.silva@email.com",
            Telefone = "(11) 98765-4321",
            EnderecoId = 1
        };

        // Act - Validando o cliente com as anota��es de dados
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(cliente, serviceProvider: null, items: null);
        var isValid = Validator.TryValidateObject(cliente, validationContext, validationResults, true);

        // Assert - Verificando que o CPF � inv�lido
        Assert.False(isValid);  // O cliente n�o deve ser v�lido
                                // Verifique diretamente se a mensagem de erro de CPF est� presente
        Assert.Contains(validationResults, vr => vr.ErrorMessage.Contains("CPF inv�lido"));
    }

    [Fact]
    public void CriarCliente_EmailInvalido_ErroValidacao()
    {
        // Arrange - Criando um cliente com e-mail inv�lido
        var cliente = new Cliente
        {
            Nome = "Jo�o da Silva",
            DataNascimento = new DateOnly(1990, 5, 20),
            CPF = "123.456.789-00",  // CPF v�lido
            Email = "invalidemail.com", // E-mail inv�lido
            Telefone = "(11) 98765-4321",  // Telefone v�lido
            EnderecoId = 1
        };

        // Act - Validando o cliente com as anota��es de dados
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(cliente, serviceProvider: null, items: null);
        var isValid = Validator.TryValidateObject(cliente, validationContext, validationResults, true);

        // Assert - Verificando que o e-mail � inv�lido
        Assert.False(isValid);  // O cliente n�o deve ser v�lido
                                // Verifique diretamente a mensagem de erro do Email, ajustando para a mensagem correta
        Assert.Contains(validationResults, vr => vr.ErrorMessage.Contains("E-mail inv�lido."));
    }

    // Outros testes podem ser adicionados conforme necess�rio, como para Telefone, DataNascimento, etc.
}