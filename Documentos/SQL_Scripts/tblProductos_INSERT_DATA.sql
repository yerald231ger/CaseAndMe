
DECLARE @idSubcatAbstracto INTEGER
DECLARE @idSubcatAnimales INTEGER
SET @idSubcatAbstracto = (SELECT id FROM tblSubCategorias WHERE Nombre = 'Abstracto')
SET @idSubcatAnimales = (SELECT id FROM tblSubCategorias WHERE Nombre = 'Animales')

INSERT INTO tblProductos(IdSubCategoria, Nombre, Descripcion, Precio, UrlImagen, EsActivo, FechaAlt, FechaMod)
VALUES(@idSubcatAbstracto, 'Case Numero 1', 'Descripcion Case Numero 1',  89.95, 'case1.jpg', 1, GETDATE(), GETDATE())

INSERT INTO tblProductos(IdSubCategoria, Nombre, Descripcion, Precio, UrlImagen, EsActivo, FechaAlt, FechaMod)
VALUES(@idSubcatAbstracto, 'Case Numero 2', 'Descripcion Case Numero 2',  89.95, 'case2.jpg', 1, GETDATE(), GETDATE())

INSERT INTO tblProductos(IdSubCategoria, Nombre, Descripcion, Precio, UrlImagen, EsActivo, FechaAlt, FechaMod)
VALUES(@idSubcatAbstracto, 'Case Numero 3', 'Descripcion Case Numero 3',  89.95, 'case3.jpg', 1, GETDATE(), GETDATE())

INSERT INTO tblProductos(IdSubCategoria, Nombre, Descripcion, Precio, UrlImagen, EsActivo, FechaAlt, FechaMod)
VALUES(@idSubcatAbstracto, 'Case Numero 4', 'Descripcion Case Numero 4',  89.95, 'case4.jpg', 1, GETDATE(), GETDATE())

INSERT INTO tblProductos(IdSubCategoria, Nombre, Descripcion, Precio, UrlImagen, EsActivo, FechaAlt, FechaMod)
VALUES(@idSubcatAbstracto, 'Case Numero 5', 'Descripcion Case Numero 5',  89.95, 'case5.jpg', 1, GETDATE(), GETDATE())

INSERT INTO tblProductos(IdSubCategoria, Nombre, Descripcion, Precio, UrlImagen, EsActivo, FechaAlt, FechaMod)
VALUES(@idSubcatAbstracto, 'Case Numero 6', 'Descripcion Case Numero 6',  89.95, 'case6.jpg', 1, GETDATE(), GETDATE())

INSERT INTO tblProductos(IdSubCategoria, Nombre, Descripcion, Precio, UrlImagen, EsActivo, FechaAlt, FechaMod)
VALUES(@idSubcatAbstracto, 'Case Numero 7', 'Descripcion Case Numero 7',  89.95, 'case7.jpg', 1, GETDATE(), GETDATE())

INSERT INTO tblProductos(IdSubCategoria, Nombre, Descripcion, Precio, UrlImagen, EsActivo, FechaAlt, FechaMod)
VALUES(@idSubcatAbstracto, 'Case Numero 8', 'Descripcion Case Numero 8',  89.95, 'case8.jpg', 1, GETDATE(), GETDATE())

INSERT INTO tblProductos(IdSubCategoria, Nombre, Descripcion, Precio, UrlImagen, EsActivo, FechaAlt, FechaMod)
VALUES(@idSubcatAbstracto, 'Case Numero 9', 'Descripcion Case Numero 9',  89.95, 'case9.jpg', 1, GETDATE(), GETDATE())

INSERT INTO tblProductos(IdSubCategoria, Nombre, Descripcion, Precio, UrlImagen, EsActivo, FechaAlt, FechaMod)
VALUES(@idSubcatAbstracto, 'Case Numero 10', 'Descripcion Case Numero 10',  89.95, 'case10.jpg', 1, GETDATE(), GETDATE())

INSERT INTO tblProductos(IdSubCategoria, Nombre, Descripcion, Precio, UrlImagen, EsActivo, FechaAlt, FechaMod)
VALUES(@idSubcatAnimales, 'Case Numero 11', 'Descripcion Case Numero 11',  89.95, 'case11.jpg', 1, GETDATE(), GETDATE())

INSERT INTO tblProductos(IdSubCategoria, Nombre, Descripcion, Precio, UrlImagen, EsActivo, FechaAlt, FechaMod)
VALUES(@idSubcatAnimales, 'Case Numero 12', 'Descripcion Case Numero 12',  89.95, 'case12.jpg', 1, GETDATE(), GETDATE())

INSERT INTO tblProductos(IdSubCategoria, Nombre, Descripcion, Precio, UrlImagen, EsActivo, FechaAlt, FechaMod)
VALUES(@idSubcatAnimales, 'Case Numero 13', 'Descripcion Case Numero 13',  89.95, 'case13.jpg', 1, GETDATE(), GETDATE())

INSERT INTO tblProductos(IdSubCategoria, Nombre, Descripcion, Precio, UrlImagen, EsActivo, FechaAlt, FechaMod)
VALUES(@idSubcatAnimales, 'Case Numero 14', 'Descripcion Case Numero 14',  89.95, 'case14.jpg', 1, GETDATE(), GETDATE())

INSERT INTO tblProductos(IdSubCategoria, Nombre, Descripcion, Precio, UrlImagen, EsActivo, FechaAlt, FechaMod)
VALUES(@idSubcatAnimales, 'Case Numero 15', 'Descripcion Case Numero 15',  89.95, 'case15.jpg', 1, GETDATE(), GETDATE())

INSERT INTO tblProductos(IdSubCategoria, Nombre, Descripcion, Precio, UrlImagen, EsActivo, FechaAlt, FechaMod)
VALUES(@idSubcatAnimales, 'Case Numero 16', 'Descripcion Case Numero 16',  89.95, 'case16.jpg', 1, GETDATE(), GETDATE())

INSERT INTO tblProductos(IdSubCategoria, Nombre, Descripcion, Precio, UrlImagen, EsActivo, FechaAlt, FechaMod)
VALUES(@idSubcatAnimales, 'Case Numero 17', 'Descripcion Case Numero 17',  89.95, 'case17.jpg', 1, GETDATE(), GETDATE())

INSERT INTO tblProductos(IdSubCategoria, Nombre, Descripcion, Precio, UrlImagen, EsActivo, FechaAlt, FechaMod)
VALUES(@idSubcatAnimales, 'Case Numero 18', 'Descripcion Case Numero 18',  89.95, 'case18.jpg', 1, GETDATE(), GETDATE())

INSERT INTO tblProductos(IdSubCategoria, Nombre, Descripcion, Precio, UrlImagen, EsActivo, FechaAlt, FechaMod)
VALUES(@idSubcatAnimales, 'Case Numero 19', 'Descripcion Case Numero 19',  89.95, 'case19.jpg', 1, GETDATE(), GETDATE())

INSERT INTO tblProductos(IdSubCategoria, Nombre, Descripcion, Precio, UrlImagen, EsActivo, FechaAlt, FechaMod)
VALUES(@idSubcatAnimales, 'Case Numero 20', 'Descripcion Case Numero 20',  89.95, 'case20.jpg', 1, GETDATE(), GETDATE())