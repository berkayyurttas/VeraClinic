# 1. AŞAMA: Derleme (Build)
FROM node:20-alpine AS builder
WORKDIR /app

# Bağımlılıkları yükle
COPY package.json package-lock.json ./
RUN npm install --legacy-peer-deps

# Proje dosyalarını kopyala ve build al
COPY . .
RUN npx ng build --configuration production

# 2. AŞAMA: Yayın (Nginx)
FROM nginx:alpine

# Nginx ayarını kopyala
COPY nginx.conf /etc/nginx/conf.d/default.conf

# KRİTİK DÜZELTME: 
# angular.json'daki base path ve browser klasörünü birleştirdik.
COPY --from=builder /app/dist/VeraClinic/browser /usr/share/nginx/html

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]