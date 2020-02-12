<template>
    <div class="row m-0 pt-4">
        <div class="offset-1 col-1 sc-kaki text-uppercase d-flex align-items-center p-0 py-4">
            <h5 class="m-0 ml-4 text-white"> {{ othergames.Id }}</h5>
        </div>
        <div class="col-3 sc-kaki text-uppercase d-flex justify-content-center align-items-center p-0 py-4">
            <h5 class="m-0 text-white"> {{ othergames.OrganizerId }} </h5>
        </div>
        <div class="col-2 sc-kaki text-uppercase d-flex justify-content-end align-items-center p-0 py-4">
            <h5 class="m-0 text-white"> {{ othergames.CreationDate }} </h5>
        </div>
        <div class="col-2 sc-kaki text-uppercase d-flex justify-content-center align-items-center p-0 py-4">
            <h5 class="m-0 text-white"> {{ othergames.TransportId}} </h5>
        </div>
        <div class="col-2 sc-kaki text-uppercase d-flex justify-content-center align-items-center p-0 py-4">
        </div>
    </div>
</template>

<script>
export default {
    name: 'OtherGames',
    props: [
        'othergames'
    ]
}
</script>