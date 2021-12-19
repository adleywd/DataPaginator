# DataPaginator

DataPaginator is a library created with purpose to make easier the processes of generate a pagination data models while using EntityFrameworkCore DbContext.

## Installation

Use the nuget pack manager to install DataPaginator.EntityFrameworkCore.Extensions:
`Install-Package DataPaginator.EntityFrameworkCore.Extensions -Version 1.0.0`
or with .Net CLI:
`dotnet add package DataPaginator.EntityFrameworkCore.Extensions--version 1.0.0`

## Usage

After nuget installation, in your repository or where you get your result model from database, you can use the IQueryable extension PaginateAsyc.

```csharp
using DataPaginator.EntityFrameworkCore.Extensions; // Namespace that allow to use PaginateAsync as IQueryable<TModel> extension
using DataPaginator.Models.Abstractions; // Namespace to the interface IPageModel
using DataPaginator.Models; // Namespace to concrete PageModel. Only necessary if you want to use the default Page Model class.
```
Note: You can create your own PageModel by creating a custom class that implements IPageModel interface.

```csharp
var result = await context.MyModel.AsNoTracking().OrderBy(d => d.Id).PaginateAsync(pageNumber, pageSize);
```
or passing the cancelation token
```csharp
var result = await context.MyModel.AsNoTracking().OrderBy(d => d.Id).PaginateAsync(pageNumber, pageSize, cancellationToken);
```

The default PaginationAsync will return a PageModel, but as I said, you can use your own IPageModel implementation.
The only requirement is that it must implements the interface: `DataPaginator.Models.Abstractions.IPageModel<TModel>`

Then, you can pass your model:
```csharp
var myCustomPageModel = new MyCustomPageModel<Model>(); 
var result = await context.MyModel.AsNoTracking().OrderBy(d => d.Id).PaginateAsync(pageNumber, pageSize, myCustomPageModel);
```
or passing the cancellation toke:
```csharp
var myCustomPageModel = new MyCustomPageModel<Model>(); 
var result = await context.MyModel.AsNoTracking().OrderBy(d => d.Id).PaginateAsync(pageNumber, pageSize, myCustomPageModel, cancellationToken);
```

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License

MIT License

Copyright (c) 2021 Adley Wollmann Damaceno

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES, OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
