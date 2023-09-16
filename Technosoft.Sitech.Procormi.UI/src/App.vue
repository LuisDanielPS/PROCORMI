<template>
    <div id="app">
        <div id="aplicacion">
            <router-view  />
            <footerComponent />
        </div>
    </div>
</template>

<script>
import footerComponent from '@/components/Footer.vue'
export default {
    name: "app",
    components: {
        footerComponent
    }
};
</script>

<style>
</style>