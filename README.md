# TexturePaint-with-ColorBlend-and-Alpha

This project is for drawing things on texture and display it with any mesh on scene.

Sample Scene ScreenShot
![Screen Shot 2023-01-11 at 10 27 18](https://user-images.githubusercontent.com/56830043/211743594-1ac95691-1a1b-4b1b-b251-d9e07187c4d6.png)

--SETUP--

First you need a base texture to be painting. It should be Read/Write enabled and wrap mode should be clamp to avoid overflows.

![Screen Shot 2023-01-11 at 10 29 00](https://user-images.githubusercontent.com/56830043/211744120-0b78267e-89b8-4ac5-bd98-1638dbbaa5bf.png)

Then you need a brush texture. The algorithm I made uses the green color and transparency on the brush to blend color. You can upload any brush fits your needs. Brush texture should Read/Write enabled and Alpha Is Transparency true.

![Screen Shot 2023-01-11 at 10 29 54](https://user-images.githubusercontent.com/56830043/211744264-4d18dead-ac0e-4b11-acb6-e3587b4bc0ed.png)

TexturePainter Script in Scene. First you need to fill References fields. brush, material on the object to be painted and base texture for that material.
Then you can customize the Options section such as brush color and brush size. For now, brush size is not used in the project, it is in development.

![Screen Shot 2023-01-11 at 10 30 23](https://user-images.githubusercontent.com/56830043/211744341-7877e028-78d6-4b64-8a10-d3937922ef06.png)

TexturePainter in scene Screenshot:
![Screen Shot 2023-01-11 at 10 31 00](https://user-images.githubusercontent.com/56830043/211744446-b71209f1-cb82-4566-b91a-ac567b4c9456.png)

Finally you need to create the object to be painted. Object should have material you set in the Texture Painter and IMPORTANT: object needs to have mesh collider(for actually to be able to paint). Because our algorithm uses Raycast and get information from hit.textureCoord. hit.textureCoord only works for mesh colliders with no convex.

![Screen Shot 2023-01-11 at 10 30 50](https://user-images.githubusercontent.com/56830043/211744500-0f5c9cd6-cdce-4711-a98b-48f61f9fdf6e.png)
