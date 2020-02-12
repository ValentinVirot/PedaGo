<template>
    <div class="trial">
        <div class="row m-0 py-4 bg-white">
            <div class="col-3 sc-dark-light p-0 d-flex justify-content-center align-items-center py-3">
                <h5 class="m-0 text-white"> Parcours </h5>
            </div>
            <div class="offset-6 col-3 sc-dark-light p-0 d-flex justify-content-center align-items-center py-3">
                <router-link class="nav-link text-white p-0" to="/createroute">
                    <h5 class="m-0"> Créer un Parcours </h5>
                </router-link>
            </div>
        </div>
        <div class="row m-0 pt-5 d-flex justify-content-center bg-white">
            <h4 class="text-dark">Mes Parcours</h4>
        </div>
        <div v-for="route of myroutes" v-bind:key="route.Id">
            <MyRoute v-bind:myroute="route" class="bg-white py-3"/>
        </div>
        <div class="row m-0 pt-5 d-flex justify-content-center text-white">
            <h4>Autres Parcours</h4>
        </div>
        <div v-for="route in otherroutes" v-bind:key="route.Id">
            <OtherRoutes v-bind:otherroute="route" class="py-3"/>
        </div>
    </div>
</template>

<script>

import MyRoute from '@/components/MyRoute';
import OtherRoutes from '@/components/OtherRoutes'
import Vue from 'vue'

export default {
    name: 'routes',
    components: {
        MyRoute,
        OtherRoutes
    },
    created: async function(){
        this.routes = await this.$getRoutes();
        this.routes.forEach((route) =>
        {
            if(route.OrganizerId == Vue.$organizerId)
            {
                this.myroutes.push(route);
            }
            else
            {
                this.otherroutes.push(route);
            }
        })
    },
    data: function(){
        return {
            myroutes :[],
            otherroutes: [],
            routes : []
        }
    }
}
</script>