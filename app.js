const organizations=[
  {name:"Aster Health",domain:"aster.example",plan:"Enterprise",seats:64,status:"Active"},
  {name:"BluePeak Logistics",domain:"bluepeak.example",plan:"Growth",seats:38,status:"Active"},
  {name:"Cedarline Studio",domain:"cedarline.example",plan:"Starter",seats:14,status:"Review"},
  {name:"DeltaWorks",domain:"deltaworks.example",plan:"Enterprise",seats:82,status:"Active"},
  {name:"Everwell Services",domain:"everwell.example",plan:"Growth",seats:50,status:"Active"}
];
const employees=[
  {name:"Maya Chen",email:"maya@aster.example",org:"Aster Health",role:"Administrator",status:"Active"},
  {name:"Jordan Reid",email:"jordan@bluepeak.example",org:"BluePeak Logistics",role:"Manager",status:"Active"},
  {name:"Elena Vargas",email:"elena@cedarline.example",org:"Cedarline Studio",role:"Member",status:"Review"},
  {name:"Noah Williams",email:"noah@deltaworks.example",org:"DeltaWorks",role:"Manager",status:"Active"},
  {name:"Amara Singh",email:"amara@everwell.example",org:"Everwell Services",role:"Member",status:"Active"}
];
const audits=[
  {time:"09:42",event:"SSO signing keys refreshed",actor:"System",target:"Microsoft Entra ID",result:"Success"},
  {time:"09:18",event:"Employee role updated",actor:"Maya Chen",target:"Jordan Reid",result:"Success"},
  {time:"Yesterday",event:"Tenant policy reviewed",actor:"Cristopher",target:"Cedarline Studio",result:"Review"},
  {time:"Yesterday",event:"New employee provisioned",actor:"Entra JIT",target:"Amara Singh",result:"Success"},
  {time:"Nov 22",event:"Organization activated",actor:"Cristopher",target:"Everwell Services",result:"Success"}
];
const activities=[
  ["MC","Maya updated a role","BluePeak Logistics · Manager permissions","8 min"],
  ["SS","Signing keys refreshed","Microsoft Entra ID metadata synchronized","12 min"],
  ["JR","Jordan invited 3 employees","Aster Health · invitations pending","31 min"],
  ["CF","Policy marked for review","Cedarline Studio · access policy","1 hr"]
];
const permissions={
  Administrator:[["View organizations",1],["Manage employees",1],["Configure SSO",1],["Review audit trail",1],["Cross-tenant impersonation",0]],
  Manager:[["View organizations",1],["Manage employees",1],["Configure SSO",0],["Review audit trail",1],["Cross-tenant impersonation",0]],
  Member:[["View organizations",0],["Manage employees",0],["Configure SSO",0],["Review audit trail",0],["Cross-tenant impersonation",0]]
};
const $=selector=>document.querySelector(selector);
const $$=selector=>[...document.querySelectorAll(selector)];
const initials=name=>name.split(/\s+/).map(x=>x[0]).slice(0,2).join("").toUpperCase();
function showToast(message){const toast=$("#toast");toast.textContent=message;toast.classList.add("show");clearTimeout(showToast.timer);showToast.timer=setTimeout(()=>toast.classList.remove("show"),2600)}
function switchView(id){$$('.view').forEach(v=>v.classList.toggle('active',v.id===id));$$('.nav-item').forEach(b=>b.classList.toggle('active',b.dataset.view===id));$("#crumb").textContent=id.replace(/-/g," ").toUpperCase();document.querySelector('.sidebar').classList.remove('open');window.scrollTo({top:0,behavior:'smooth'})}
$$('.nav-item').forEach(button=>button.addEventListener('click',()=>switchView(button.dataset.view)));
$$('[data-view-link]').forEach(button=>button.addEventListener('click',()=>switchView(button.dataset.viewLink)));
$('.mobile-menu').addEventListener('click',()=>$('.sidebar').classList.toggle('open'));
function renderActivity(){$('#activityList').innerHTML=activities.map(([avatar,title,detail,time])=>`<div class="activity-item"><span class="activity-avatar">${avatar}</span><div><b>${title}</b><p>${detail}</p></div><time>${time}</time></div>`).join('')}
function renderOrganizations(){const q=$('#orgSearch').value.toLowerCase();const status=$('#statusFilter').value;const list=organizations.filter(o=>(o.name+o.domain).toLowerCase().includes(q)&&(status==='all'||o.status===status));$('#orgTable').innerHTML=`<div class="table-row header"><span>ORGANIZATION</span><span>PLAN</span><span>EMPLOYEES</span><span>STATUS</span><span></span></div>`+(list.length?list.map(o=>`<div class="table-row"><div class="entity"><span class="entity-icon">${initials(o.name)}</span><div><b>${o.name}</b><small>${o.domain}</small></div></div><span>${o.plan}</span><span>${o.seats} seats</span><span class="status ${o.status==='Active'?'online':'review'}">${o.status==='Active'?'ACTIVE':'REVIEW'}</span><button class="row-menu" aria-label="More options">···</button></div>`).join(''):`<div class="empty">No organizations match this filter.</div>`)}
function renderEmployees(){const q=$('#employeeSearch').value.toLowerCase();const role=$('#roleFilter').value;const list=employees.filter(e=>(e.name+e.email+e.org).toLowerCase().includes(q)&&(role==='all'||e.role===role));$('#employeeTable').innerHTML=`<div class="table-row employee header"><span>EMPLOYEE</span><span>ORGANIZATION</span><span>ROLE</span><span>STATUS</span><span></span></div>`+(list.length?list.map(e=>`<div class="table-row employee"><div class="entity"><span class="entity-icon">${initials(e.name)}</span><div><b>${e.name}</b><small>${e.email}</small></div></div><span>${e.org}</span><span>${e.role}</span><span class="status ${e.status==='Active'?'online':'review'}">${e.status.toUpperCase()}</span><button class="row-menu" aria-label="More options">···</button></div>`).join(''):`<div class="empty">No employees match this filter.</div>`)}
function renderAudits(){$('#auditTable').innerHTML=`<div class="table-row audit header"><span>TIME</span><span>EVENT</span><span>ACTOR</span><span>TARGET</span><span>RESULT</span></div>`+audits.map(a=>`<div class="table-row audit"><span>${a.time}</span><b>${a.event}</b><span>${a.actor}</span><span>${a.target}</span><span class="status ${a.result==='Success'?'online':'review'}">${a.result.toUpperCase()}</span></div>`).join('')}
function renderPermissions(){const role=$('#policyRole').value;$('#permissionMatrix').innerHTML=permissions[role].map(([name,allowed])=>`<div class="policy-row"><b>${name}</b><span class="${allowed?'allow':'deny'}">${allowed?'✓ ALLOW':'— DENY'}</span></div>`).join('')}
$('#orgSearch').addEventListener('input',renderOrganizations);$('#statusFilter').addEventListener('change',renderOrganizations);$('#employeeSearch').addEventListener('input',renderEmployees);$('#roleFilter').addEventListener('change',renderEmployees);$('#policyRole').addEventListener('change',renderPermissions);
const modal=$('#orgModal');$$('[data-open-modal]').forEach(b=>b.addEventListener('click',()=>modal.showModal()));
$('#orgForm').addEventListener('submit',event=>{if(event.submitter?.value==='cancel')return;event.preventDefault();const name=$('#newOrgName').value.trim();if(!name)return;organizations.unshift({name,domain:name.toLowerCase().replace(/[^a-z0-9]+/g,'')+'.example',plan:$('#newOrgPlan').value,seats:Number($('#newOrgSeats').value),status:'Active'});$('#orgMetric').textContent=String(organizations.length+7).padStart(2,'0');audits.unshift({time:'Now',event:'Organization created',actor:'Cristopher',target:name,result:'Success'});renderOrganizations();renderAudits();modal.close();event.target.reset();showToast(`${name} created in this demo session`)});
$('#inviteButton').addEventListener('click',()=>showToast('Sample invitation prepared — no email was sent'));
$('#testSso').addEventListener('click',()=>{const result=$('#ssoResult');result.textContent='Testing discovery document, issuer, JWKS and redirect URI…';$('#entraStatus').textContent='CHECKING';setTimeout(()=>{result.textContent='✓ Connection healthy · issuer and signing keys validated';$('#entraStatus').textContent='CONNECTED';audits.unshift({time:'Now',event:'SSO connection tested',actor:'Cristopher',target:'Microsoft Entra ID',result:'Success'});renderAudits()},1100)});
$('#rotateKeys').addEventListener('click',()=>{showToast('Signing keys refreshed from Entra metadata');audits.unshift({time:'Now',event:'SSO signing keys refreshed',actor:'Cristopher',target:'Microsoft Entra ID',result:'Success'});renderAudits()});
$('#focusSearch').addEventListener('click',()=>{switchView('organizations');setTimeout(()=>$('#orgSearch').focus(),150)});
document.addEventListener('keydown',event=>{if((event.metaKey||event.ctrlKey)&&event.key.toLowerCase()==='k'){event.preventDefault();$('#focusSearch').click()}});
$('#exportAudit').addEventListener('click',()=>{const lines=['Time,Event,Actor,Target,Result',...audits.map(a=>[a.time,a.event,a.actor,a.target,a.result].map(v=>`"${String(v).replaceAll('"','""')}"`).join(','))];const url=URL.createObjectURL(new Blob([lines.join('\n')],{type:'text/csv'}));const link=document.createElement('a');link.href=url;link.download='orgcontrol-sample-audit.csv';link.click();URL.revokeObjectURL(url);showToast('Sample audit CSV exported')});
renderActivity();renderOrganizations();renderEmployees();renderAudits();renderPermissions();
