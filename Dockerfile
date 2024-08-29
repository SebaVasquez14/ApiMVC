FROM mcr.microsoft.com/dotnet/framework/aspnet:4.6.2
EXPOSE 56637
COPY . /inetpub/wwwroot

#FROM mcr.microsoft.com/dotnet/framework/aspnet:4.6.2
#
## 1. Directorio de trabajo temporal
#WORKDIR /app
#
## 2. Copiar solo los archivos de proyecto y solución (.csproj y .sln)
#COPY *.csproj *.sln ./
#
## 3. Restaurar dependencias (NuGet packages)
#RUN nuget restore
#
## 4. Copiar el resto del código fuente
#COPY . ./
#
## 5. Publicar la aplicación en modo Release
#RUN msbuild /p:Configuration=Release
#
## 6. Copiar los archivos publicados a la ruta de despliegue de IIS
#COPY /app/bin/Release /inetpub/wwwroot