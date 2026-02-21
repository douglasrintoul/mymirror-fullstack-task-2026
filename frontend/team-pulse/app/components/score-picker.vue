<script setup lang="ts">
const props = withDefaults(defineProps<{
	max?: number | null;
	value: number | null;
}>(), { max: 5 });

defineEmits<{
	'update:value': [value: number];
}>();
</script>

<template>
	<div class="score-picker">
		<button
			v-for="n in props.max"
			:key="n"
			type="button"
			class="score-option"
			:class="{ selected: value === n }"
			@click="$emit('update:value', n)"
		>
			{{ n }}
		</button>
	</div>
</template>

<style scoped>
.score-picker {
  display: flex;
  justify-content: space-between;
}

.score-option {
  width: 3rem;
  height: 3rem;
  border-radius: 50%;
  border: 2px solid #eee;
  background: #fff;
  color: #333;
  font-size: 1.1rem;
  font-weight: 600;
  cursor: pointer;
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 0;
  transition: all 0.15s ease;
}

.score-option:hover {
  border-color: #666;
}

.score-option.selected {
  background: var(--hero-orange);
  color: #fff;
  border-color: var(--hero-orange);
}
</style>
