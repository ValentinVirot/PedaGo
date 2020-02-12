<template>
    <div class="row m-0 pt-5">
        <div class="offset-1 col-lg-2 sc-kaki text-uppercase d-flex align-items-center p-0 py-4">
            <span class="m-0 ml-4 text-white"> {{ route.Name }} </span>
        </div>
        <div class="col-lg-1 sc-kaki d-flex justify-content-center align-items-center p-0 py-4">
            <v-icon color="#ffffff" v-if="route.Handicap == true">mdi-36px mdi-wheelchair-accessibility</v-icon>
        </div>
        <div class="col-lg-4 sc-kaki d-flex justify-content-center align-items-center p-0 py-4">
            <span class="m-0 text-white">{{ route.Description }}</span>
        </div>
        <div class="col-lg-2 sc-kaki d-flex justify-content-end align-items-center p-0 py-4">
            <span class="m-0 text-white"> {{ route.Distance }} km </span>
        </div>
        <div class="col-lg-1 sc-kaki d-flex justify-content-center align-items-center p-0 py-4">
        </div>
    </div>
</template>



<script>
export default {
    name : 'AllRoutes',
    props : [
        'route'
    ]
}
</script>

