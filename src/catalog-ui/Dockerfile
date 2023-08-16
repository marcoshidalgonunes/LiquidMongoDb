FROM node:alpine as builder
ARG REACT_APP_API_URL
ENV REACT_APP_API_URL $REACT_APP_API_URL
WORKDIR /app
COPY . .
RUN npm install -g pnpm
RUN pnpm install
RUN pnpm build

FROM nginx:alpine as prod
WORKDIR /usr/share/nginx/html
COPY --from=builder /app/build ./
EXPOSE 80
ENTRYPOINT ["nginx", "-g", "daemon off;"]