USE [ECommerceDemo]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 05/09/2021 1:06:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [bigint] IDENTITY(1,1) NOT NULL,
	[ProdCatId] [int] NOT NULL,
	[ProdName] [varchar](250) NOT NULL,
	[ProdDescription] [varchar](max) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductAttribute]    Script Date: 05/09/2021 1:06:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductAttribute](
	[ProductId] [bigint] NOT NULL,
	[AttributeId] [int] NOT NULL,
	[AttributeValue] [varchar](250) NULL
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_GetEditDaa]    Script Date: 05/09/2021 1:06:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_GetEditDaa]
as                                        
select prod.ProductId,
		prod.ProdCatId,
		prod.ProdName,
		prod.ProdDescription,
		ProductAttribute.AttributeId,
		ProductAttribute.AttributeValue
from Product as prod
	Left Join ProductAttribute on ProductAttribute.ProductId = prod.ProductId 
GO
/****** Object:  View [dbo].[View_GetEditid]    Script Date: 05/09/2021 1:06:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_GetEditid]
as                                        
select prod.ProductId,
		prod.ProdCatId,
		prod.ProdName,
		prod.ProdDescription,
		ProductAttribute.AttributeId,
		ProductAttribute.AttributeValue
from Product as prod
	Left Join ProductAttribute on ProductAttribute.ProductId = prod.ProductId 
GO
/****** Object:  Table [dbo].[ProductAttributeLookup]    Script Date: 05/09/2021 1:06:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductAttributeLookup](
	[AttributeId] [int] IDENTITY(1,1) NOT NULL,
	[ProdCatId] [int] NOT NULL,
	[AttributeName] [varchar](250) NOT NULL,
 CONSTRAINT [PK_ProductAttributeLookup] PRIMARY KEY CLUSTERED 
(
	[AttributeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 05/09/2021 1:06:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[ProdCatId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](250) NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[ProdCatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductId], [ProdCatId], [ProdName], [ProdDescription]) VALUES (1, 2, N'Nokia', N'this products are Nokia Mobile')
INSERT [dbo].[Product] ([ProductId], [ProdCatId], [ProdName], [ProdDescription]) VALUES (2, 1, N'Maruti', N'Giid condition')
INSERT [dbo].[Product] ([ProductId], [ProdCatId], [ProdName], [ProdDescription]) VALUES (3, 2, N'Samsung', N'this products are Sam Mobile')
INSERT [dbo].[Product] ([ProductId], [ProdCatId], [ProdName], [ProdDescription]) VALUES (4, 2, N'Mi Note', N'this products are Nokia Mobile')
INSERT [dbo].[Product] ([ProductId], [ProdCatId], [ProdName], [ProdDescription]) VALUES (5, 1, N'Toyota', N'new')
INSERT [dbo].[Product] ([ProductId], [ProdCatId], [ProdName], [ProdDescription]) VALUES (6, 1, N'Swift', N'new')
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
INSERT [dbo].[ProductAttribute] ([ProductId], [AttributeId], [AttributeValue]) VALUES (1, 4, N'3 GB')
INSERT [dbo].[ProductAttribute] ([ProductId], [AttributeId], [AttributeValue]) VALUES (2, 1, N'Red')
INSERT [dbo].[ProductAttribute] ([ProductId], [AttributeId], [AttributeValue]) VALUES (3, 4, N'5 GB')
INSERT [dbo].[ProductAttribute] ([ProductId], [AttributeId], [AttributeValue]) VALUES (4, 4, N'6 GB')
INSERT [dbo].[ProductAttribute] ([ProductId], [AttributeId], [AttributeValue]) VALUES (5, 1, N'Black')
INSERT [dbo].[ProductAttribute] ([ProductId], [AttributeId], [AttributeValue]) VALUES (6, 2, N'1989')
GO
SET IDENTITY_INSERT [dbo].[ProductAttributeLookup] ON 

INSERT [dbo].[ProductAttributeLookup] ([AttributeId], [ProdCatId], [AttributeName]) VALUES (1, 1, N'Color')
INSERT [dbo].[ProductAttributeLookup] ([AttributeId], [ProdCatId], [AttributeName]) VALUES (2, 1, N'Make')
INSERT [dbo].[ProductAttributeLookup] ([AttributeId], [ProdCatId], [AttributeName]) VALUES (3, 1, N'Model')
INSERT [dbo].[ProductAttributeLookup] ([AttributeId], [ProdCatId], [AttributeName]) VALUES (4, 2, N'RAM')
INSERT [dbo].[ProductAttributeLookup] ([AttributeId], [ProdCatId], [AttributeName]) VALUES (5, 2, N'Front Camera')
INSERT [dbo].[ProductAttributeLookup] ([AttributeId], [ProdCatId], [AttributeName]) VALUES (6, 2, N'Rear Camera')
SET IDENTITY_INSERT [dbo].[ProductAttributeLookup] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 

INSERT [dbo].[ProductCategory] ([ProdCatId], [CategoryName]) VALUES (1, N'Car')
INSERT [dbo].[ProductCategory] ([ProdCatId], [CategoryName]) VALUES (2, N'Mobile')
INSERT [dbo].[ProductCategory] ([ProdCatId], [CategoryName]) VALUES (3, N'Cloth')
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductCategory] FOREIGN KEY([ProdCatId])
REFERENCES [dbo].[ProductCategory] ([ProdCatId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductCategory]
GO
ALTER TABLE [dbo].[ProductAttribute]  WITH CHECK ADD  CONSTRAINT [FK_ProductAttribute_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[ProductAttribute] CHECK CONSTRAINT [FK_ProductAttribute_Product]
GO
ALTER TABLE [dbo].[ProductAttribute]  WITH CHECK ADD  CONSTRAINT [FK_ProductAttribute_ProductAttributeLookup] FOREIGN KEY([AttributeId])
REFERENCES [dbo].[ProductAttributeLookup] ([AttributeId])
GO
ALTER TABLE [dbo].[ProductAttribute] CHECK CONSTRAINT [FK_ProductAttribute_ProductAttributeLookup]
GO
ALTER TABLE [dbo].[ProductAttributeLookup]  WITH CHECK ADD  CONSTRAINT [FK_ProductAttributeLookup_ProductCategory] FOREIGN KEY([ProdCatId])
REFERENCES [dbo].[ProductCategory] ([ProdCatId])
GO
ALTER TABLE [dbo].[ProductAttributeLookup] CHECK CONSTRAINT [FK_ProductAttributeLookup_ProductCategory]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllProduct]    Script Date: 05/09/2021 1:06:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE Proc [dbo].[sp_GetAllProduct]  
@PageNo INT ,  
@PageSize INT ,  
@SortOrder VARCHAR(200)  
As  

Begin

	--declare @PageNo INT = 1 ,  @PageSize INT = 10
    Select * From   (Select ROW_NUMBER() Over (  

    Order by ProdName ) AS 'RowNum', *

         from   [product] 
		
        )t 
		 inner join ProductCategory on ProductCategory.ProdCatId = t.ProdCatId
		 inner join ProductAttributeLookup on ProductAttributeLookup.ProdCatId = ProductCategory.ProdCatId
		  inner join ProductAttribute on ProductAttribute.ProductId = t.ProductId and ProductAttribute.AttributeId = ProductAttributeLookup.AttributeId
		where t.RowNum Between ((@PageNo-1)*@PageSize +1) AND (@PageNo*@pageSize)  order by t.ProductId desc
End 
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertUpdateProduct]    Script Date: 05/09/2021 1:06:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_InsertUpdateProduct]  
(  
@productid bigint,
@prodcatid int,  
@prodname varchar(250),
@proddescription varchar(Max),
@attributeid int,  
@attributevalue varchar(250),
@DATAOPMODE as int 
)  
as  
IF(@DATAOPMODE = 1)                            
BEGIN    
		 Declare @id As Int

		INSERT INTO Product
		([ProdCatId], [ProdName], [ProdDescription])  
		VALUES(@prodcatid,@prodname,@proddescription)

		select  @id = Scope_Identity()

		INSERT INTO ProductAttribute
		(ProductId, AttributeId, AttributeValue)  
		VALUES(@id,@attributeid,@attributevalue)

END
ELSE IF(@DATAOPMODE = 2)
BEGIN    
		Update Product Set ProdName=@prodname, ProdDescription = @proddescription						
		Where ProductId=@productid


		Update ProductAttribute Set AttributeId=@attributeid, AttributeValue = @attributevalue						
		Where ProductId=@productid
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertUpdateProductcategory]    Script Date: 05/09/2021 1:06:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_InsertUpdateProductcategory]  
(  

@prodcatid int,  
@categoryname varchar(250),

@DATAOPMODE as int 
)
as  
IF(@DATAOPMODE = 1)                            
BEGIN    
		INSERT INTO ProductCategory
		(CategoryName)  
		VALUES(@categoryname)

END
ELSE IF(@DATAOPMODE = 2)
BEGIN    
		Update ProductCategory Set CategoryName=@categoryname
		Where ProdCatId=@prodcatid
END
GO
