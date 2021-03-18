using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SmartLocker.WebAPI.Contracts.DTOs.External.Requests;
using SmartLocker.WebAPI.Data;
using SmartLocker.WebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartLocker.WebAPI.Services
{
    public class ServiceBookService
    {
        private readonly ApplicationContext applicationContext;
        private readonly IStringLocalizer localizer;

        public ServiceBookService(ApplicationContext applicationContext, IStringLocalizer localizer)
        {
            this.applicationContext = applicationContext;
            this.localizer = localizer;
        }

        public async Task<List<ServiceBook>> GetAllAsync() =>
            await applicationContext.ServiceBooks.ToListAsync();

        public async Task<ServiceBook> GetOneAsync(Guid id)
        {
            ServiceBook book = await applicationContext.ServiceBooks.AsNoTracking().FirstOrDefaultAsync(sb => sb.Id == id);

            if (book is null)
                throw new Exception(localizer["Service book with this identifier doesn`t exist."]);

            return book;
        }

        public async Task CreateAsync(ServiceBook book)
        {
            if (await GetOneAsync(book.Id) is not null)
                throw new Exception(localizer["Service book already exists."]);

            await applicationContext.ServiceBooks.AddAsync(book);
            await applicationContext.SaveChangesAsync();
        }

        public async Task<ServiceBook> EditAsync(Guid id, ServiceBookEditRequest request)
        {
            ServiceBook newBook = new(id, request.LastServiceDate, request.MsBetweenServices, request.MaxUsages, request.Usages);
            ServiceBook book = await GetOneAsync(id);

            book = newBook;

            applicationContext.ServiceBooks.Update(book);
            await applicationContext.SaveChangesAsync();

            return await GetOneAsync(id);
        }

        public async Task DeleteAsync(Guid id)
        {
            ServiceBook book = await GetOneAsync(id);

            applicationContext.ServiceBooks.Remove(book);
            await applicationContext.SaveChangesAsync();
        }
    }
}
