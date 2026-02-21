<script setup lang="ts">
import type { PulseFormData } from '~/types/pulse-form';

defineProps<{
	loading: boolean;
	showSuccessMessage: boolean;
	error: string;
}>();

const emit = defineEmits<{
	submit: [data: PulseFormData];
}>();

const formData = reactive<PulseFormData>({
	score: null,
	category: '',
	comment: '',
});
</script>

<template>
	<ScorePicker
		:max="5"
		:value="formData.score"
		@update:value="formData.score = $event"
	/>
	<select
		v-model="formData.category"
		name="category"
	>
		<option
			selected
			disabled
			value=""
		>
			Pulse Category
		</option>
		<option>Category 1</option>
		<option>Category 2</option>
	</select>
  <input
    v-model="formData.comment"
    name="comment"
    placeholder="Optional comment"
  >
  <div>
    <p v-if="showSuccessMessage">
      <Icon
			name="proicons:checkmark-circle"
			style="position: relative; top: 2px;"
      /> Pulse submitted - thank you!
    </p>
    <p v-if="error" style="color: red">
      {{ error }}
    </p>
    <LoadingSpinner v-if="loading" />
  </div>
	<button
		class="submit-pulse-button"
		:disabled="loading"
		@click="emit('submit', { ...formData })"
	>
		Submit Pulse
	</button>
</template>

<style scoped>
.submit-pulse-button {
  background-color: var(--hero-orange);
  border-color: var(--hero-orange);
  width: 100%;
  color: var(--hero-blue);
  font-weight: bold;
}
</style>
