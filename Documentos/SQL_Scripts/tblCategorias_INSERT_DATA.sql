

INSERT INTO tblCategorias(EsActivo, FechaAlt, FechaMod, Nombre) VALUES(1, GETDATE(), GETDATE(), 'Cases')
INSERT INTO tblCategorias(EsActivo, FechaAlt, FechaMod, Nombre) VALUES(1, GETDATE(), GETDATE(), 'Tazas')
INSERT INTO tblCategorias(EsActivo, FechaAlt, FechaMod, Nombre) VALUES(1, GETDATE(), GETDATE(), 'Termos')
INSERT INTO tblCategorias(EsActivo, FechaAlt, FechaMod, Nombre) VALUES(1, GETDATE(), GETDATE(), 'Vasos')
INSERT INTO tblCategorias(EsActivo, FechaAlt, FechaMod, Nombre) VALUES(1, GETDATE(), GETDATE(), 'Gorras')
INSERT INTO tblCategorias(EsActivo, FechaAlt, FechaMod, Nombre) VALUES(1, GETDATE(), GETDATE(), 'Otros')

DECLARE @idCategoria INTEGER
SET @idCategoria = (SELECT id FROM tblCategorias WHERE Nombre = 'Cases')
INSERT INTO tblSubCategorias(EsActivo, FechaAlt, FechaMod, IdCategoria, Nombre) VALUES(1, GETDATE(), GETDATE(), @idCategoria, 'Abstracto')
INSERT INTO tblSubCategorias(EsActivo, FechaAlt, FechaMod, IdCategoria, Nombre) VALUES(1, GETDATE(), GETDATE(), @idCategoria, 'Amor')
INSERT INTO tblSubCategorias(EsActivo, FechaAlt, FechaMod, IdCategoria, Nombre) VALUES(1, GETDATE(), GETDATE(), @idCategoria, 'Animales')
INSERT INTO tblSubCategorias(EsActivo, FechaAlt, FechaMod, IdCategoria, Nombre) VALUES(1, GETDATE(), GETDATE(), @idCategoria, 'Anime')
INSERT INTO tblSubCategorias(EsActivo, FechaAlt, FechaMod, IdCategoria, Nombre) VALUES(1, GETDATE(), GETDATE(), @idCategoria, 'Caricaturas')
INSERT INTO tblSubCategorias(EsActivo, FechaAlt, FechaMod, IdCategoria, Nombre) VALUES(1, GETDATE(), GETDATE(), @idCategoria, 'Ciencia Ficcion')
INSERT INTO tblSubCategorias(EsActivo, FechaAlt, FechaMod, IdCategoria, Nombre) VALUES(1, GETDATE(), GETDATE(), @idCategoria, 'Computadoras')
INSERT INTO tblSubCategorias(EsActivo, FechaAlt, FechaMod, IdCategoria, Nombre) VALUES(1, GETDATE(), GETDATE(), @idCategoria, 'Deportes')
INSERT INTO tblSubCategorias(EsActivo, FechaAlt, FechaMod, IdCategoria, Nombre) VALUES(1, GETDATE(), GETDATE(), @idCategoria, 'Fantasia')
INSERT INTO tblSubCategorias(EsActivo, FechaAlt, FechaMod, IdCategoria, Nombre) VALUES(1, GETDATE(), GETDATE(), @idCategoria, 'Flores')
INSERT INTO tblSubCategorias(EsActivo, FechaAlt, FechaMod, IdCategoria, Nombre) VALUES(1, GETDATE(), GETDATE(), @idCategoria, 'Hombres')
INSERT INTO tblSubCategorias(EsActivo, FechaAlt, FechaMod, IdCategoria, Nombre) VALUES(1, GETDATE(), GETDATE(), @idCategoria, 'Juegos')
INSERT INTO tblSubCategorias(EsActivo, FechaAlt, FechaMod, IdCategoria, Nombre) VALUES(1, GETDATE(), GETDATE(), @idCategoria, 'Marcas')
INSERT INTO tblSubCategorias(EsActivo, FechaAlt, FechaMod, IdCategoria, Nombre) VALUES(1, GETDATE(), GETDATE(), @idCategoria, 'Mujeres')
INSERT INTO tblSubCategorias(EsActivo, FechaAlt, FechaMod, IdCategoria, Nombre) VALUES(1, GETDATE(), GETDATE(), @idCategoria, 'Musica')
INSERT INTO tblSubCategorias(EsActivo, FechaAlt, FechaMod, IdCategoria, Nombre) VALUES(1, GETDATE(), GETDATE(), @idCategoria, 'Naturaleza')
INSERT INTO tblSubCategorias(EsActivo, FechaAlt, FechaMod, IdCategoria, Nombre) VALUES(1, GETDATE(), GETDATE(), @idCategoria, 'Peliculas')
INSERT INTO tblSubCategorias(EsActivo, FechaAlt, FechaMod, IdCategoria, Nombre) VALUES(1, GETDATE(), GETDATE(), @idCategoria, 'Texturas')
INSERT INTO tblSubCategorias(EsActivo, FechaAlt, FechaMod, IdCategoria, Nombre) VALUES(1, GETDATE(), GETDATE(), @idCategoria, 'Vehiculos')

--SELECT * FROM tblCategorias
--SELECT * FROM tblSubCategorias