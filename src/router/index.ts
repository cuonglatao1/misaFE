import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/salarycomposition',
      name: 'SalaryComposition',
      component: () => import('../views/SalaryComposition.vue'),
    },
    {
      path: '/salarycomposition/add',
      name: 'SalaryCompositionAdd',
      component: () => import('../views/SalaryCompositionForm.vue'),
    },
    {
      path: '/salarycomposition/edit/:id',
      name: 'SalaryCompositionEdit',
      component: () => import('../views/SalaryCompositionForm.vue'),
    },
  ],
})

export default router
