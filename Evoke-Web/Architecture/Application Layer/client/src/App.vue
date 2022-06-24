<template>
  <v-app>
    <v-layout ref="app">
      <v-navigation-drawer
        app
        left
        permanent
        color="primary-darken-1"
        v-model="menu"
      >
        <v-img
          contain
          alt="Application Title"
          class="shrink mr-2"
          src="./assets/application-title.png"
          transition="scale-transition"
        />
      </v-navigation-drawer>

      <v-app-bar app color="primary">
        <template v-slot:append>
          <v-btn icon v-on:click="menu = !menu">
            <v-icon icon="mdi-chart-gantt" />
          </v-btn>

          <v-btn icon @click="changeTheme()">
            <v-icon icon="mdi-theme-light-dark"></v-icon>
          </v-btn>
        </template>
      </v-app-bar>
      <v-main app>
        <v-container fluid>
          <v-card height="800px">
            <router-view />
          </v-card>
        </v-container>
      </v-main>
    </v-layout>
  </v-app>
</template>

<script lang="ts">
import { useTheme } from "vuetify";

export default {
  setup() {
    const theme = useTheme();

    return {
      theme,
      changeTheme: () =>
        (theme.global.name.value = theme.global.current.value.dark
          ? "light"
          : "dark"),
    };
  },

  data: () => ({
    menu: true,
  }),
};
</script>
