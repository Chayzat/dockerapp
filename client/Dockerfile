FROM node:17-alpine
WORKDIR /src
COPY package.json .
RUN yarn install
COPY . .
CMD ["yarn", "run", "dev"]