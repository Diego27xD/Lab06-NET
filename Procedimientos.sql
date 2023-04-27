CREATE PROCEDURE [dbo].[ActualizarProducto]
	@IdProducto VARCHAR(20),
	@Nombre VARCHAR(20),
        @Precio DECIMAL(10,2),
	@Estado BIT
AS
BEGIN 
	UPDATE product SET [Nombre] = @Nombre, [Precio] = @Precio, [Estado] = @Estado where [IdProducto] = @IdProducto;
END

CREATE PROCEDURE [dbo].[BuscarProducto] 
as
BEGIN
select * from product;
END

CREATE PROCEDURE [dbo].[EliminarProducto]
	@IdProducto VARCHAR(20),
	@Estado BIT
AS
BEGIN 
	UPDATE product SET [Estado] = @Estado where [IdProducto] = @IdProducto;
END

CREATE PROCEDURE [dbo].[InsertProduct] 
    @IdProducto VARCHAR(20),
    @Nombre VARCHAR(20),
    @Precio DECIMAL(10,2),
	@Estado BIT
AS
BEGIN
    INSERT INTO product(IdProducto,Nombre, Precio, Fecha_creacion, Estado)
    VALUES (@IdProducto, @Nombre, @Precio, GETDATE(), @Estado)
END


CREATE PROCEDURE [dbo].[ListarProductos] 
as
BEGIN
select * from product where [Estado] = 1;
END
