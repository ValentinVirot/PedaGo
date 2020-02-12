<template>
    <div class="row m-0 pt-4">
        <div class="offset-1 col-lg-2 sc-kaki text-uppercase d-flex align-items-center p-0 py-4">
            <h5 class="m-0 ml-4 text-white"> {{ trial.Name }} </h5>
        </div>
        <div class="col-lg-3 sc-kaki text-uppercase d-flex justify-content-center align-items-center p-0 py-4">
            <h5 class="m-0"></h5>
        </div>
        <div class="col-lg-2 sc-kaki text-uppercase d-flex justify-content-end align-items-center p-0 py-4">
            <h5 class="m-0 text-white"> {{ trial.Trials.length }} épreuve </h5>
        </div>
        <div class="col-lg-2 sc-kaki text-uppercase d-flex justify-content-center align-items-center p-0 py-4">
            <h5 class="m-0 text-white"> {{ trial.Score}} points </h5>
        </div>
        <div class="col-lg-1 sc-kaki text-uppercase d-flex justify-content-center align-items-center p-0 py-4">
        </div>
    </div>
</template>

<script>
export default {
    name : 'Mission',
    props : [
        'mission'
    ]
}
</script>