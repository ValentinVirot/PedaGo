<template>
    <div class="offset-2 col-3 d-flex justify-content-center align-items-center">
        <span class="text-white">{{ this.mission[0].Name }} </span>
    </div>
</template>

<script>
export default {
    name : 'stepmission',
    props: [
        'mission'
    ]
}
</script>