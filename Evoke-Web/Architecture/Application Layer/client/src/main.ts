import "vuetify/styles";
import "@mdi/font/css/materialdesignicons.css";

import { createApp } from "vue";
import { createVuetify, ThemeDefinition } from "vuetify";

import App from "./App.vue";
import router from "./router";
import store from "./store";

import * as components from "vuetify/components";
import * as directives from "vuetify/directives";

const evoke: ThemeDefinition = {
  dark: true,
  colors: {
    primary: "#BB86FC",
    secondary: "#03DAC6",

    "primary-darken-1": "#3700B3",
    "secondary-darken-1": "#018786",

    error: "#CF6679",
    warning: "#FFC107",
    info: "#009688",
    success: "#4CAF50",

    background: "#121212",
    surface: "#121212",

    "on-background": "#FFFFFF",
    "on-surface": "#FFFFFF",
    "on-error": "#000000",
    "on-warning": "#000000",
    "on-info": "#000000",
    "on-success": "#000000",
  },
};

const arrigotti: ThemeDefinition = {
  dark: false,
  colors: {
    primary: "#6200EE",
    secondary: "#03DAC6",

    "primary-darken-1": "#3700B3",
    "secondary-darken-1": "#018786",

    error: "#B00020",
    warning: "#FFC107",
    info: "#009688",
    success: "#4CAF50",

    background: "#FFFFFF",
    surface: "#FFFFFF",

    "on-background": "#000000",
    "on-surface": "#000000",
    "on-error": "#FFFFFF",
    "on-warning": "#FFFFFF",
    "on-info": "#FFFFFF",
    "on-success": "#FFFFFF",
  },
};

const application = createApp(App);
const vuetify = createVuetify({
  components,
  directives,
  theme: {
    defaultTheme: "arrigotti",
    variations: {
      colors: ["primary", "secondary"],
      lighten: 1,
      darken: 2,
    },
    themes: {
      arrigotti,
      evoke,
    },
  },
});

application.use(store);
application.use(router);
application.use(vuetify);

application.mount("#app");
