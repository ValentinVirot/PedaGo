<template>
    <div class="trial">
        <div class="row m-0 py-4">
            <div class="col-3 sc-dark-light p-0 d-flex justify-content-center align-items-center py-3">
                <h5 class="m-0 text-white"> Créer un Jeu </h5>
            </div>
        </div>
        <div class="row m-0 pt-5">
            <div class="offset-1 col-2 p-0 d-flex justify-content-center align-items-center py-3 sc-item">
                <button class="btn-lg sc-pink text-white mt-5" @click="route()" type="button">A partir d'un parcours</button>
            </div>
            <div class="offset-6 col-2 p-0 d-flex justify-content-center align-items-center py-3 sc-item">
                <button class="btn-lg sc-pink text-white mt-5" @click="createRoute()" type="button">Nouveau parcours</button>
            </div>
        </div>
        <div v-for="route in routes" v-bind:key="route.Id">
            <router-link :to="{ name: 'newgame', params: { route } }" class="nav-link text-white p-0" >
               <AllRoutes v-if="display != ''" v-bind:route="route"></AllRoutes>     
            </router-link>
        </div>
    </div>
</template>

<script>
import AllRoutes from '@/components/AllRoutes'

export default {
    name : 'CreateGame',
    components : {
        AllRoutes
    },
    data : function(){
        return {
            display : '',
            routes : []
        } 
    },
    methods : {
        route(){
            this.display = 'afficher';
        },
        createRoute(){
            this.$router.push('/createroute');
        }
    },
    async created(){
        this.routes = await this.$getRoutes();
    }
}
</script>