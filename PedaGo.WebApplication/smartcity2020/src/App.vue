<template>
  <v-app>
    <v-app-bar app color="sc-dark-light">
      <div class="d-flex align-center">
        <v-img alt="Vuetify Logo" class="round-brand-logo" src="@/assets/logo.png" transition="scale-transition" width="40"/>
        <router-link class="nav-link text-white p-0" to="/">
                    <h4 class="m-0"> Peda'Go </h4>
        </router-link>
        <router-link class="nav-link text-white p-0" to="/routes">
                    <h6 class="m-0 mx-4">Parcours </h6>
        </router-link>
        <router-link class="nav-link text-white p-0" to="/games">
                    <h6 class="m-0 mx-4">Jeu </h6>
        </router-link>
        <router-link class="nav-link text-white p-0" to="/players">
                    <h6 class="m-0 mx-4">Joueurs </h6>
        </router-link>
        <router-link class="nav-link text-white p-0" to="/ir">
                    <h6 class="m-0 mx-4">Immersive Reader </h6>
        </router-link>
      </div>
    </v-app-bar>
    <v-content class="sc-dark">
      <router-view></router-view>
    </v-content>
  </v-app>
</template>

<script>
export default {
  name: 'App',

  data: () => ({
    //
  }),
};
</script>
