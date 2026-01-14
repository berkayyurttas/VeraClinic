# Stage 1: Build
FROM node:20 AS build
WORKDIR /app
COPY package*.json ./
RUN npm install --legacy-peer-deps
COPY . .
RUN npm run build --configuration=production

# Stage 2: Serve with Nginx
FROM nginx:alpine
# ✅ Klasör yolunu wildcard (*) ile düzelttik, böylece isim fark etmeksizin dosyaları bulur
COPY --from=build /app/dist/*/browser /usr/share/nginx/html
# Eğer Angular sürümün 17 altındaysa yukarıdaki satırı şununla değiştir: 
# COPY --from=build /app/dist/* /usr/share/nginx/html

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]