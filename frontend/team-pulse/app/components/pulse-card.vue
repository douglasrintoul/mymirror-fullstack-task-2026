<template>
    <article data-theme="light" class="pulse-card" >
        <slot />
    </article>
</template>

<style scoped>
.pulse-card {
    max-width: 500px;
    margin: 0 auto;
    padding: 20px 40px;
    border: 2px solid #eee;
    border-radius: 5px;
}
</style>