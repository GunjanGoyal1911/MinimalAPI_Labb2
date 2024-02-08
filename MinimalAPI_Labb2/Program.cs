using Microsoft.EntityFrameworkCore;
using MinimalAPI_Labb2.DB;
using MinimalAPI_Labb2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ProductConnectionString")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Get all products
app.MapGet("/products", async (ProductContext context) =>
{
	 var products = await context.Products.ToListAsync();
	return Results.Ok(products);
	
});

//Get product by Id
app.MapGet("/product/{id}", async(ProductContext context, int id) =>
{
	var product = await context.Products.FindAsync(id);
	if(product is null)
	{
		return Results.NotFound("Sorry, This product doesn't exist");
	}
	return Results.Ok(product);
});

// Add a product in the database
app.MapPost("/product", async (ProductContext context, Product product) =>
{
	context.Products.Add(product);
	await context.SaveChangesAsync();
	return Results.Ok("Product has been added successfully");
});

// Update product
app.MapPut("/product/{id}", async (ProductContext context, Product product, int id) =>
{
	var updatedProduct = await context.Products.FindAsync(id); 
	if(product is null)
	{
		return Results.NotFound("Sorry, This product not found");
	}
	updatedProduct.Name = product.Name;
	updatedProduct.Type = product.Type;
	await context.SaveChangesAsync();
	return Results.Ok("Product has been updated successfully");

});

//Delete a product

app.MapDelete("/product/{id}", async (ProductContext context, int id) =>
{
	var productToDelete = await context.Products.FindAsync(id);
	if (productToDelete is null)
	{
		return Results.NotFound("Sorry, This product doesn't exist");
	}
	context.Products.Remove(productToDelete);
	await context.SaveChangesAsync();
	return Results.Ok("Product has been deleted successfully");

});


app.Run();


