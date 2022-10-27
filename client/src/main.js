import { createApp } from "vue";
import App from "./App.vue";
import Home from "./Home.vue";
import About from "./About.vue";
import { createRouter, createWebHistory } from "vue-router";
const routes = [
  { path: "/", component: Home },
  { path: "/about", component: About },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});
const app = createApp(App);
app.use(router);
app.mount("#app");
