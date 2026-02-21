<script setup lang="ts">
const scoreValue = ref<number | null>(null);
const selectedCategory = ref<string>("");
const comment = ref<string>("");
</script>

<template>
    <PulseCard>
        <h2>How Are You Feeling Today?</h2>
        <ScorePicker :max="5" :value="scoreValue" @update:value="scoreValue = $event" />
        <select v-model="selectedCategory" name="category" placeholder="Hello?">
            <option selected disabled value="">Pulse Category</option>
            <option>Category 1</option>
            <option>Category 2</option>
        </select>
        <input v-model="comment" name="comment" placeholder="Optional comment">
    </PulseCard>
</template>