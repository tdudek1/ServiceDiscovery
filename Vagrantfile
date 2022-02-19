Vagrant.configure("2") do |config|

 config.hostmanager.enabled = true
 config.hostmanager.manage_guest  = true 
 config.vm.synced_folder ".", "/vagrant"
 
 config.vm.define "server" do |server|
    server.vm.box = "generic/centos7"
    server.vm.network "public_network",  use_dhcp_assigned_default_route: true
    server.vm.hostname = "server10.home"

   server.vm.provision 'ansible_local', run: 'always', type: :ansible_local do |ansible| 
    ansible.playbook = "server.yml"
    ansible.become = true
    ansible.verbose = "vvv"
    ansible.galaxy_roles_path = "/etc/ansible/roles"   
    ansible.galaxy_role_file = "requirements.yml" 
    ansible.galaxy_command = "sudo ansible-galaxy install -r %{role_file} -p %{roles_path} -f && sudo ansible-galaxy collection install -r %{role_file} -p /usr/share/ansible/collections -f" 
  end
 end
end 