FROM node:alpine as builder
WORKDIR /app
COPY . .
COPY .env.docker .env
COPY .env.desktop .env.desktop
RUN npm install -g pnpm
RUN pnpm install
RUN pnpm build

FROM nginx:alpine as prod
WORKDIR /usr/share/nginx/html
COPY --from=builder /app/build ./
EXPOSE 80
ENTRYPOINT ["nginx", "-g", "daemon off;"]